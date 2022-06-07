#include<Servo.h>

Servo Xservo;
Servo Yservo;
Servo Zservo;

const int XservoBack = 0;
const int YservoBack = 0;
const int XservoZero = 93;
const int YservoZero = 94;
const int XservoFore = 180;
const int YservoFore = 180;

bool debug;

char CMD;

unsigned long elementNum;

//declaring pins
const int XservoPin = 2;
const int YservoPin = 3;
const int plasmaPin = 4;
const int XendPin = 5;
const int YendPin = 6;
const int pwrPin = 7;

const float travelSpeed = 1;
const float accuracy = 1; //10+ is roughing for debug purposes
const float milliSecPerThou = 25.833;// change later based on experience
const int roundOff = 2;

double Xstart;
double Ystart;
double Xend;
double Yend;

double a;
double b;
double c;
double d;
double e;
double f;

double t;
double ang1;
double ang2;
double distance;
double travelTime;

double locX;
double locY;

double Xh1;
double Yh1;
double Xh2;
double Yh2;

void setup() 
{
  // put your setup code here, to run once:
  Xservo.attach(XservoPin);
  Yservo.attach(YservoPin);
  pinMode(plasmaPin,OUTPUT);
  pinMode(XendPin,INPUT);
  pinMode(YendPin,INPUT);
  pinMode(pwrPin,OUTPUT);
  digitalWrite(pwrPin,HIGH);
  Serial.begin(9600);
  Xservo.write(XservoZero);
  Yservo.write(YservoZero);
  while(Serial.peek()==-1){}
  if(Serial.read()=='D'){
    debug=true;
    Serial.println("CookieWare v0.9");
  }
  else
  {
    debug = false;
    Serial.println("Cookie Cutter Connected");
  }
  if(debug==false)
  {
    homeAxes();
  }
  else{
    Serial.println("Debug override on homing axes");
  }
  locX = 1;
  locY = 1;
}
