import speech_recognition as sr
import pyaudio
import wave
import tempfile
import audioop

# Initialize the recognizer
recognizer = sr.Recognizer()

# Initialize PyAudio to capture audio
audio = pyaudio.PyAudio()

# Set parameters for audio capture
sample_rate = 44100  # Standard sample rate
chunk_size = 1024  # Adjust as needed
audio_stream = None

# Open an audio stream
for i in range(audio.get_device_count()):
    device_info = audio.get_device_info_by_index(i)
    print(
        f"Device {i}: {device_info['name']}, Max Input Channels: {device_info['maxInputChannels']}"
    )

# Choose the desired audio input device
input_device_index = 1  # Adjust this to the correct device index

# Open an audio stream with the correct format
audio_stream = audio.open(
    format=pyaudio.paInt16,  # Use paInt16 for 16-bit audio data
    channels=1,  # Use 1 channel for mono audio
    rate=sample_rate,
    input=True,
    input_device_index=input_device_index,
    frames_per_buffer=chunk_size,
)

print("Listening...")

# Initialize variables to track audio and transcription
audio_buffer = []
text = ""

# Adjust the threshold for speech detection
# threshold = 300  # You can experiment with this value

# Listen continuously
while True:
    try:
        # Read audio chunk from the stream
        audio_chunk = audio_stream.read(chunk_size)
        audio_buffer.append(audio_chunk)

        # Process audio chunk with speech recognition
        if audioop.max(audio_chunk, 2):
            audio_data = sr.AudioData(audio_chunk, sample_rate, sample_width=2)
            text += recognizer.recognize_sphinx(audio_data)

    except sr.UnknownValueError:
        pass  # No speech detected in this chunk

    # Check for a period of silence (end of speech)
    if len(audio_buffer) > 10:  # Adjust the number of chunks to consider as silence
        break

# Close the audio stream and PyAudio
audio_stream.stop_stream()
audio_stream.close()
audio.terminate()

# Print the transcription
print("Transcription: " + text)
