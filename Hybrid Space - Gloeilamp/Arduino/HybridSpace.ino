const int pinA = 5;
const int pinB = 3; 
const int interval = 42;  
const int minSoftTurn = 2;
const int minHardTurn = 5;
int encoderPosCount = 0; 
long previousMillis;
int aVal; 
int pinALast;

 void setup() {
   pinMode (pinA,INPUT);
   pinMode (pinB,INPUT);
   pinALast = digitalRead(pinA);
   Serial.begin(9600);
 } 

 void loop() { 
  timer1();
  timer2();
  //Serial.println(encoderPosCount);
 }

 void timer1(){
    aVal = digitalRead(pinA);
    
    if(aVal != pinALast) {
      if (digitalRead(pinB) != aVal) { 
        encoderPosCount ++;
      } 
      else {
        encoderPosCount--;
      }
    }
    pinALast = aVal;
 }

 void timer2() {
     unsigned int currentMillis = millis();

     if(currentMillis - previousMillis > interval) {
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
        }
  
        previousMillis = currentMillis;
     }
  }
