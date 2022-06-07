void moveEllipse()
{
  if(debug==true)
  {
    Serial.print("Ellipse at ");
    serialPoint(Xstart,Ystart);
    Serial.print(" with radius ");
    serialPoint(Xend,Yend);
    Serial.println();
  }
  
  //calculate distance
  distance = 2*PI*(Xend+Yend)/2;
  
  //start moving
  moveTo(cos(ang1*PI/180)*Xend,
         sin(ang1*PI/180)*Yend,
         false);
  t=ang1*PI/180;
  while(t<ang2*PI/180){
    moveTo(cos(t)*Xend+Xstart,
           sin(t)*Yend+Ystart,
           true);
    t += accuracy/distance;
  }
}
