/*
 Name:		SketchArduino.ino
 Created:	30/09/2020 19:17:57
 Author:	facundo
*/

//////Variables para el datacube
typedef struct {
    uint8_t r;
    uint8_t g;
    uint8_t b;
} color;

color initColor(uint8_t r, uint8_t g, uint8_t b) {
    color c;
    c.r = r;
    c.g = g;
    c.b = b;
    return c;
}

uint8_t generatedColor[3];
int generatedColorIndex = 0;

color colors[3];
//////FIN////Variables para el datacube

int valor = 0;

int LEDr = 11;
int LEDg = 10;
int LEDb = 9;

void setup()
{
    Serial.begin(9600);
    SetColor(initColor(255, 0, 0));
}

void loop()
{
    while (Serial.available() > 0)
    {
        Serial.println(Serial.available());
        uint8_t info = Serial.read();
        if (info >= 0)
        {
            generatedColor[generatedColorIndex++] = info;

            if (generatedColorIndex >= 3) {
                colors[0] = initColor(generatedColor[0], generatedColor[1], generatedColor[2]);
                generatedColorIndex = 0;
                generatedColor[0] = 0;
                generatedColor[1] = 0;
                generatedColor[2] = 0;
                break;
            }
        }
    }


    SetColor(colors[0]);
}

void SetColor(color c)
{
    analogWrite(LEDr, c.r);
    analogWrite(LEDg, c.g);
    analogWrite(LEDb, c.b);
}