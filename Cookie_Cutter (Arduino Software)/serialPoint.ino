void serialPoint(float x, float y){
  if(debug==true){
  Serial.print((int)x,DEC);
  Serial.print(",");
  Serial.print((int)y,DEC);
  }
}
