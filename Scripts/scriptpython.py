import numpy as np
import cv2
from keras.preprocessing import image

# Elegir si utilizar CUDA o no
cuda = False

# Si se utiliza CUDA, prepara la sesión de Keras para utilizar la GPU
if cuda:
    import tensorflow as tf
    sess = tf.compat.v1.Session(config=tf.compat.v1.ConfigProto(log_device_placement=True))

# Clasificador en cascada
face_cascade = cv2.CascadeClassifier('D:/Users/JP/PycharmProjects/pythonProject/haarcascade_frontalface_default.xml')

# Entrada de vídeo
cap = cv2.VideoCapture(0)

# Carga del modelo y sus pesos
from keras.models import model_from_json
model = model_from_json(open("D:/Users/JP/PycharmProjects/pythonProject/clairvoyant.json", "r").read())
model.load_weights('D:/Users/JP/PycharmProjects/pythonProject/clairvoyant.h5')

emotions = ('angry', 'disgust', 'fear', 'happy', 'sad', 'surprise', 'neutral')

while(True):
    # Captura el frame que ve la cámara
    ret, img = cap.read()

    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

    # Detecta la cara
    faces = face_cascade.detectMultiScale(gray, 1.3, 5)

    for (x, y, w, h) in faces:
        # Recorta la cara y la transforma a 48x48 píxeles
        detected_face = img[int(y):int(y+h), int(x):int(x+w)]
        detected_face = cv2.cvtColor(detected_face, cv2.COLOR_BGR2GRAY)
        detected_face = cv2.resize(detected_face, (48, 48))

        img_pixels = image.img_to_array(detected_face)
        img_pixels = np.expand_dims(img_pixels, axis=0)

        img_pixels /= 255

        # Predice la expresión
        predictions = model.predict(img_pixels)
        max_index = np.argmax(predictions[0])
        emotion = emotions[max_index]

        print(emotion + "\n")

cap.release()
cv2.destroyAllWindows()
