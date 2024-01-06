import spacy
import re
from collections import defaultdict

nlp = spacy.load("en_core_web_sm")


def parse_email_log(file_path):
    parsed_data = []

    # open and read the content of the file
    with open(file_path, "r") as file:
        lines = file.readlines()

    # move through lines in the file
    current_email = None
    for line in lines:
        line = line.strip()

        # check if the line starts with an email address
        if re.match(r"[^@]+@[^@]+\.[^@]+", line):
            current_email = {"sender": line, "text": ""}
        elif line == "<<End>>":
            if current_email:
                parsed_data.append(current_email)
                current_email = None
        elif current_email:
            current_email["text"] += line + " "

    # use spaCy for POS tagging and entity recognition
    for user_email in parsed_data:
        doc = nlp(user_email["text"])
        user_email["tokens"] = [
            {"text": token.text, "pos": token.pos_, "ent_type": token.ent_type_}
            for token in doc
        ]

    # output clean data to text file
    with open("clean_data.txt", "w") as output_file:
        for user_email in parsed_data:
            output_file.write(f"Sender: {user_email['sender']}\n")
            output_file.write("Tokens:\n")
            for token in user_email["tokens"]:
                output_file.write(
                    f"  {token['text']} - POS: {token['pos']}, Entity: {token['ent_type']}\n"
                )
            output_file.write("<<End>>\n")

    return parsed_data


def format_currency(amount):
    return "${:,.2f}".format(amount)


def clean_amount_string(amount_str):
    # Remove special characters and symbols except for digits and '.'
    cleaned_str = "".join(char for char in amount_str if char.isdigit() or char == ".")
    return cleaned_str


def aggregate_investment_data(parsed_data):
    # Dictionary to store aggregated investment information for each sender
    investment_data = defaultdict(
        lambda: {"total_investment": 0, "investments": defaultdict(float)}
    )
    total_investment = 0

    for email_info in parsed_data:
        sender = email_info["sender"]
        tokens = email_info["tokens"]

        # Extract investment information from the email text
        investment_amount = 0
        investment_target = None
        for token in tokens:
            if token["ent_type"] == "MONEY":
                cleaned_amount = clean_amount_string(token["text"])
                if cleaned_amount:
                    investment_amount += float(cleaned_amount)
            elif token["ent_type"] == "ORG" and investment_amount > 0:
                investment_data[sender]["investments"][
                    token["text"]
                ] += investment_amount
                investment_data[sender]["total_investment"] += investment_amount
                investment_amount = 0

    # Output the aggregated investment information
    with open("summary_report.txt", "w") as output_file:
        for sender, data in investment_data.items():
            total_investment += data["total_investment"]
            formatted_investments = ", ".join(
                f"{format_currency(amount)} to {company}"
                for company, amount in data["investments"].items()
            )
            print(f"{sender}: {formatted_investments}")
            output_file.write(f"{sender}: {formatted_investments}\n")
        total_investment_formatted = format_currency(total_investment)
        print(f"Total Requests: {total_investment_formatted}")
        output_file.write(f"Total Requests: {total_investment_formatted}\n")


# py file start (the main)
if __name__ == "__main__":
    parsed_data = parse_email_log("EmailLog.txt")
    aggregate_investment_data(parsed_data)
