import speech_recognition as sr
from pydub import AudioSegment

# Convert MP3 to WAV

mp3_audio = AudioSegment.from_mp3("hello.mp3")
mp3_audio.export("hello.wav", format="wav")

# Initialize the recognizer
recognizer = sr.Recognizer()

# Load the audio file
audio_file = "hello.wav"

# Load the audio file into the recognizer
with sr.AudioFile(audio_file) as source:
    # Adjust for ambient noise, if necessary
    recognizer.adjust_for_ambient_noise(source)

    # Perform speech recognition
    try:
        audio = recognizer.record(source)
        text = recognizer.recognize_google(audio)  # You can choose other engines too
        print("Transcription: " + text)

        # Save the transcription to a text file
        with open("transcription.txt", "w") as text_file:
            text_file.write("Transcription: " + text)
            print("Transcription saved to 'transcription.txt'")
    except sr.UnknownValueError:
        print("Google Speech Recognition could not understand the audio.")
    except sr.RequestError as e:
        print("Could not request results from Google Speech Recognition; {0}".format(e))
