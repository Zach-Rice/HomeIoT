
#include <dht.h>


dht DHT;
#define dhtpin 3
 
void setup(){   
  Serial.begin(9600);
  delay(1000); 
} 
void loop(){
    DHT.read11(dhtpin);
    delay(500);
    float tempc = DHT.temperature;
    float tempf = (tempc*1.8)+32;
    int temp = round(tempf);
    Serial.println(temp);
    delay(2000);
}
