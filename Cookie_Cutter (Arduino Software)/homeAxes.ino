void homeAxes(){
  
  locX = (float)random(2,25000);
  locY = (float)random(2,25000);
 
  Serial.println("Homnig axes");
    
  Xservo.write(XservoBack);
  Yservo.write(YservoBack);
    
  while((locX != 0) || (locY != 0))
  {
    if(digitalRead(XendPin)==HIGH && locX != 0)
    {
      Serial.println("X homed");
      Xservo.write(XservoZero);
      locX = 0;
    }
    if(digitalRead(YendPin)==HIGH && locY != 0){
      Serial.println("Y homed");
      Yservo.write(YservoZero);
      locY = 0;
    }
  }
}
