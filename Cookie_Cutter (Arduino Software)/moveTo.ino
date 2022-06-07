void moveTo(float Xorigonal, float Yorigonal, bool cutting){
  double Xgoal = Xorigonal * a + Yorigonal * c + e;
  double Ygoal = Xorigonal * b + Yorigonal * d + f;
  double movLength = sqrt(sq(Xgoal - locX) + sq(Ygoal - locY));
  Xservo.write(moveServo(locX, Xgoal, XservoZero));
  Yservo.write(moveServo(locY, Ygoal, YservoZero));
  
  if(debug == true)
  {
    if(cutting == true)
    {
      Serial.print("\nCutting ");
    }
    else
    {
      Serial.print("\nMoving ");
    }
    Serial.print("from ");
    serialPoint(locX,locY);
    Serial.print(" to ");
    serialPoint(Xgoal,Ygoal);
    Serial.print(" dxdy ");
    Serial.print((Xgoal - locX) / (Ygoal - locY), DEC);
  }
  delay((int)(movLength * milliSecPerThou));
  Xservo.write(XservoZero);
  Yservo.write(YservoZero);
  locX = Xgoal;
  locY = Ygoal;
}
