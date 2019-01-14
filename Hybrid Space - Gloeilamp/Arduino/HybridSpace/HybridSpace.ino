const int pinA = 5;
const int pinB = 3; 
const int interval = 24;  
const int minSoftTurn = 2;
const int minHardTurn = 5;
long previousMillis;
int encoderPosCount = 0; 
int aVal; 
int pinALast;
bool isTurning;
long index = 0;

 void setup() {
   pinMode (pinA,INPUT);
   pinMode (pinB,INPUT);
   pinALast = digitalRead(pinA);
   Serial.begin(9600);
 } 

 void loop() { 
  timer1();
  timer2();
 }

 void timer1(){
    aVal = digitalRead(pinA);
    index++;
    if(aVal != pinALast) {
      isTurning = true;
      if (digitalRead(pinB) != aVal) encoderPosCount ++;
      else encoderPosCount--;
    }
    if(index >= 125000){
      encoderPosCount = 0;
      index = 0;
      isTurning = false;
    }
    pinALast = aVal;
 }

 void timer2() {
     unsigned long currentMillis = millis();

     if(currentMillis - previousMillis > interval) {
        if(isTurning && encoderPosCount >= 3) {
            Serial.flush();
            Serial.println(1);
        }
        else if (isTurning && encoderPosCount <= -3) {
          Serial.flush();
          Serial.println(2);
        }
        else {
          Serial.flush();
          Serial.println(0);
        }

      
      /*
        if(encoderPosCount > minSoftTurn && encoderPosCount < minHardTurn) {
           Serial.flush();
           Serial.println(1);
        }
        else if(encoderPosCount < -minSoftTurn && encoderPosCount > -minHardTurn) {
           Serial.flush();
           Serial.println(2);
        }
        else if (encoderPosCount >= minHardTurn){
          Serial.flush();
          Serial.println(3);
        }
        else if (encoderPosCount <= -minHardTurn){
          Serial.flush();
          Serial.println(4);
        }
        else {
           Serial.flush();
           Serial.println(0);
        } */
  
        previousMillis = currentMillis;
     }
  }
