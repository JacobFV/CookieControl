void curve()
{
  if(debug==true)
  {
    Serial.print("Curve from ");
    serialPoint(Xstart,Ystart);
    Serial.print(" to ");
    serialPoint(Xend,Yend);
    Serial.print(" p1 ");
    serialPoint(Xh1,Yh1);
    Serial.print(" p2 ");
    serialPoint(Xh2,Yh2);
    Serial.println();
  }
    
  //find distance
  double cx = 3 * (Xh1-Xstart);
  double bx = 3 * (Xh2-Xh1)-cx;
  double ax = Xend - Xstart - cx - bx;
  double cy = 3 * (Yh1-Ystart);
  double by = 3 * (Yh2-Yh1)-cy;
  double ay = Yend - Ystart - cy - by;
  distance = sqrt(sq(1.5*ax + 2*bx + cx)
                + sq(1.5*ay + 2*by + cy));
  //start moving
  moveTo(Xstart, Ystart, false);
  while(t<=1)
  {
    moveTo(ax*pow(t,3)+bx*sq(t)+cx*t+Xstart,
           ay*pow(t,3)+by*sq(t)+cy*t+Ystart,
           true);
    t += accuracy / distance;
  }
}
