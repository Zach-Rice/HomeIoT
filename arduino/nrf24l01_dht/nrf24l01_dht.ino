#include <SPI.h>
#include <nRF24L01.h>
#include <RF24.h>

#include <LiquidCrystal_I2C.h>
#include <dht.h>

const uint64_t pipeOut = 0xE8E8F0F0E1LL;
RF24 radio(9, 10);

LiquidCrystal_I2C lcd(0x27,16,2);
dht DHT;
#define dhtpin 3

 struct MyData {
  int t;
};
MyData data;

void setup() {
  Serial.begin(9600);
  delay(1000);
  
  radio.begin();  
  radio.setChannel(115); 
  radio.setPALevel(RF24_PA_LOW);
  radio.setAutoAck(false);
  radio.setDataRate( RF24_250KBPS ) ; 
  radio.openWritingPipe(pipeOut);
    
  lcd.init();
  lcd.backlight();
  delay(1000); 
}

void loop() {
  lcd.setCursor(0,0);  
  DHT.read11(dhtpin);
  delay(500);
  float tempc = DHT.temperature;
  float tempf = (tempc*1.8)+32;
  int temp = round(tempf);
  data.t = temp;
  lcd.print("temp = ");
  lcd.print(data.t);
  radio.write(&data, sizeof(MyData));
}
