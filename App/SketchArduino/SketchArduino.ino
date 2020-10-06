/*
 Name:		SketchArduino.ino
 Created:	30/09/2020 19:17:57
 Author:	facundo
*/
String inputString = "";         // a string to hold incoming data
boolean stringComplete = false;  // whether the string is complete
String commandString = "";

int led1Pin = 2;

boolean isConnected = false;
//////////COLORES PARA EL LED////////////
typedef struct {
    int r;
    int g;
    int b;
} Color;
Color Led;
int LEDr = 11;
int LEDg = 10;
int LEDb = 9;
////FIN//////////////////////////////////

//////////////////RELES//////////////////
typedef struct {
    int id;
    int pin;
    bool state;
} Rele;
Rele Reles[2]{
  {1,2,false},
  {2,4,false}
};

// Reles[0].id= 1;
// Reles[0].pin= 2;
// Reles[0].state=false;
// Reles[1].id=2;
// Reles[1].pin=4;
// Reles[1].state=false;
////FIN//////////////////////////////////

void setup() {
    Serial.begin(9600);
    pinMode(led1Pin, OUTPUT);
    pinMode(11, OUTPUT);
    pinMode(10, OUTPUT);
    pinMode(9, OUTPUT);
    pinMode(Reles[0].pin, OUTPUT);
    pinMode(Reles[1].pin, OUTPUT);
}



void loop() {

    serialEvent();

    if (stringComplete)
    {
        //  Serial.println("stringcompleto: " + String(inputString));

        stringComplete = false;
        getCommand();

        if (commandString.equals("STAR"))
        {

        }
        if (commandString.equals("SETC"))//SET COLOR
        {
            String text = getText();
            getColores(text);
            SetColor(Led);
        }
        else if (commandString.equals("TEXT"))
        {
            String text = getText();
            printText(text);
        }
        else if (commandString.equals("RELE"))
        {
            String texto = getText();
            Rele rele = getRele(texto);
            if (rele.state == true)
            {
                digitalWrite(rele.pin, LOW);
                Reles[rele.id - 1].state = false;
            }
            else
            {
                digitalWrite(rele.pin, HIGH);
                Reles[rele.id - 1].state = true;
            }
        }
        else if (commandString.equals("HUME"))
        {
            Serial.println(String(analogRead(A0)));
            //    int lecturaHumedad = analogRead(A0);
            //    if(lecturaHumedad >=1000){
            //    Serial.println(">>EL SENSOR ESTA DESCONECTADO O FUERA DE SUELO<<");
            //    }else if(lecturaHumedad <=1000 && lecturaHumedad >= 600){
            //          Serial.println(">>EL SUELO ESTA SECO. VALOR: <<" + String(lecturaHumedad));
            //      }else if(lecturaHumedad <600 && lecturaHumedad >= 370){
            //          Serial.println(">>EL SUELO ESTA HUEDO(recomendado). VALOR: <<" + String(lecturaHumedad));
            //      }else if(lecturaHumedad <370){
            //          Serial.println(">>EL SUELO ESTA PRACTICAMENTE SUMERGIDO EN AGUA(no recomendado). VALOR: <<" + String(lecturaHumedad));
            //      }
        }

        inputString = "";
    }

}

void serialEvent() {
    while (Serial.available()) {
        // get the new byte:
        char inChar = (char)Serial.read();
        // add it to the inputString:
        inputString += inChar;
        // if the incoming character is a newline, set a flag
        // so the main loop can do something about it:
        if (inChar == '\n') {
            stringComplete = true;
        }
    }
}
void getCommand()
{
    if (inputString.length() > 0)
    {

        uint8_t info = Serial.read();
        commandString = inputString.substring(1, 5);
        if (info >= 0)
        {

        }
    }
}

void getColores(String texto)
{
    int indexR = texto.indexOf('R');
    int indexG = texto.indexOf('G');
    int indexB = texto.indexOf('B');

    //  #SETCR123G23B1#
      //desde la posicion 5 del string porque se quita el #TEXT, y .length()-2 para quitar el \n
    String color = texto.substring(indexR, indexR + 1);//  Serial.println(color);
    String valor = texto.substring(indexR + 1, indexG);//  Serial.println(valor);
    Led.r = valor.toInt();
    color = texto.substring(indexG, indexG + 1);//  Serial.println(color);
    valor = texto.substring(indexG + 1, indexB);//  Serial.println(valor);
    Led.g = valor.toInt();

    color = texto.substring(indexB, indexB + 1);//  Serial.println(color);
    valor = texto.substring(indexB + 1, texto.length());//  Serial.println(valor);
    Led.b = valor.toInt();

    //  Serial.print("colores: r:"+String(Led.r)+"g:"+String(Led.g)+"b:"+String(Led.b));
}

String getText()
{
    //desde la posicion 5 del string porque se quita el #TEXT, y .length()-2 para quitar el \n
    String value = inputString.substring(5, inputString.length() - 2);
    return value;
}

void printText(String text)
{
    if (text == "pito")
        LucesTesteo();
    Serial.print("Imprimiendo texto: " + String(text));
    Serial.println();
}

Rele getRele(String texto) {
    int indexI = texto.indexOf('I');
    String caracter = texto.substring(indexI, indexI + 1);//  Serial.println(caracter;
    int id = texto.substring(indexI + 1, texto.length()).toInt();//  Serial.println(id);

    Rele rele;
    rele.id = Reles[id - 1].id;
    rele.pin = Reles[id - 1].pin;
    rele.state = Reles[id - 1].state;
    return rele;
}

void SetColor(Color ledx) {
    analogWrite(LEDr, ledx.r);
    analogWrite(LEDg, ledx.g);
    analogWrite(LEDb, ledx.b);
}

void LucesTesteo() {
    analogWrite(11, 255);
    analogWrite(10, 255);
    analogWrite(9, 255);
    delay(250);
    analogWrite(11, 0);
    analogWrite(10, 0);
    analogWrite(9, 0);
    delay(250);
    analogWrite(11, 255);
    analogWrite(10, 255);
    analogWrite(9, 255);
    delay(250);
    analogWrite(11, 0);
    analogWrite(10, 0);
    analogWrite(9, 0);
    delay(250);
}

