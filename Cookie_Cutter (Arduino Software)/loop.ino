void loop() {
  //intro data
  t = 0;
  Serial.print("\nElement#");
  Serial.print(elementNum,DEC);
  Serial.print(":");
  CMD = Serial.read();
  while(CMD < 97)
  {
    CMD = Serial.read();
  }
  Serial.println(CMD);
  
  //global vars
  Xstart = Serial.parseFloat();
  Ystart = Serial.parseFloat();
  Xend = Serial.parseFloat();
  Yend = Serial.parseFloat();
  
  switch(CMD){
    case 'z': //set zero
      locX = Xstart;
      locY = Ystart;
      if(debug == true)
      {
        Serial.print("X loc");
        Serial.println(locX, DEC);
        
        Serial.print("Y loc");
        Serial.println(locY, DEC);
      }
    break;
    case 'c': //curve
      
      // matricies
      a = Serial.parseFloat();
      b = Serial.parseFloat();
      c = Serial.parseFloat();
      d = Serial.parseFloat();
      e = Serial.parseFloat();
      f = Serial.parseFloat();
      
      Xh1 = Serial.parseFloat();
      Yh1 = Serial.parseFloat();
      Xh2 = Serial.parseFloat();
      Yh2 = Serial.parseFloat();
      
      curve();
      
    break;
    case 'l': //line
    
      a=1;
      b=0;
      c=0;
      d=1;
      e=0;
      f=0;
      
      moveLine();
    break;
    case 'e': //ellipse
      
      // matricies
      a = Serial.parseFloat();
      b = Serial.parseFloat();
      c = Serial.parseFloat();
      d = Serial.parseFloat();
      e = Serial.parseFloat();
      f = Serial.parseFloat();
      
      ang1 = Serial.parseFloat(); //X/Y-start is the center
      ang2 = Serial.parseFloat(); //X/Y-end is the radius
      
      moveEllipse();
    break;
  }
  elementNum++;
}
