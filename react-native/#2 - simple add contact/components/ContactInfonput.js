import React, { useState } from "react";
import { View, StyleSheet, TextInput, Button, Modal } from "react-native";

const ContactInfoInput = (props) => {
  const [enteredName, setContactInfoName] = useState();
  const [enteredEmail, setContactInfoEmail] = useState();

  const nameInputHandler = (nameValue) => {
    setContactInfoName(nameValue);
  };

  const emailInputHandler = (emailValue) => {
    setContactInfoEmail(emailValue);
  };

  const combine = () => {
    const nameAndemail = enteredName + " / " + enteredEmail;
    addItemHandler(nameAndemail);
  };

  const addItemHandler = (emailandname) => {
    props.onAddItem(emailandname);
    setContactInfoName("");
    setContactInfoEmail("");
  };

  return (
    <Modal visible={props.visible} animationType="slide">
      <View style={styles.inputContainer}>
        <TextInput
          placeholder="Name"
          style={styles.input}
          onChangeText={nameInputHandler}
          value={enteredName}
        />

        <TextInput
          placeholder="Number/Email Adress"
          style={styles.input}
          onChangeText={emailInputHandler}
          value={enteredEmail}
        />
        <View style={styles.buttonContainer}>
          <View style={styles.button}>
            <Button title="CANCEL" color="red" onPress={props.onCancel} />
          </View>
          <View style={styles.button}>
            <Button title="ADD" onPress={combine} />
          </View>
        </View>
      </View>
    </Modal>
  );
};

const styles = StyleSheet.create({
  inputContainer: {
    flex: 1,
    flexDirection: "column",
    justifyContent: "center",
    alignItems: "center",
  },
  input: {
    width: "80%",
    borderColor: "black",
    borderWidth: 1,
    padding: 10,
    marginBottom: 10,
  },
  buttonContainer: {
    flexDirection: "row",
    justifyContent: "space-between",
    width: "60%",
  },
  button: {
    width: "40%",
  },
});

export default ContactInfoInput;
