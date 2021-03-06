const int pinA = 5;
const int pinB = 3; 
const int buttonPin = 8;
const int infraPin = A0;
const int interval = 42;  
unsigned long previousMillis;
float proximity;
int encoderPosCount = 0; 
int aVal; 
int pinALast;
bool isTurning;
bool buttonDown;
long index = 0;

 void setup() {
   pinMode (pinA,INPUT);
   pinMode (pinB,INPUT);
   pinMode (infraPin,INPUT);
   pinMode (buttonPin, INPUT);
   pinALast = digitalRead(pinA);
   Serial.begin(38400);
 } 

 void loop() { 
  timer1();
  timer2();
 }

 void timer1(){
    aVal = digitalRead(pinA);
    int infraRead = analogRead(infraPin);
    proximity = (float)infraRead * 5.0 / 1023.0;
    index++;
    if(aVal != pinALast) {
      isTurning = true;
      if (digitalRead(pinB) != aVal) encoderPosCount ++;
      else encoderPosCount--;
    }
    if(index >= 10000){
      encoderPosCount = 0;
      index = 0;
      isTurning = false;
    }
    buttonDown = digitalRead(buttonPin) ? true : false;
    pinALast = aVal;
 }

 void timer2() {
     unsigned long currentMillis = millis();

     if(currentMillis - previousMillis > interval) {
      if(isTurning){
        if(proximity <= 4) {
          Serial.flush();
          Serial.write(5);
        }
        else if (buttonDown) {
          Serial.flush();
          Serial.write(6);  
        }
        else if(encoderPosCount >= 10) {
          Serial.flush();
          Serial.write(3);
        }
        else if(encoderPosCount <= -10) {
          Serial.flush();
          Serial.write(4);
        }
        else if(encoderPosCount > 0) {
          Serial.flush();
          Serial.write(1);
        }
        else if (encoderPosCount < 0) {
          Serial.flush();
          Serial.write(2);
        }
        else {
          Serial.flush();
          Serial.write(0);
        }
      }
       else if(proximity <= 4) {
          Serial.flush();
          Serial.write(5);
        }
        else if (buttonDown) {
          Serial.flush();
          Serial.write(6);  
        }
        else {
          Serial.flush();
          Serial.write(0);
        }
  
        previousMillis = currentMillis;
     }
  }
