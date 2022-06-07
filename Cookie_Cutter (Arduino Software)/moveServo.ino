int moveServo(float startNum, float endNum, int zero)
{
  double diff = endNum - startNum;
  if(diff == 0)
  {
    return zero;
  }
  else if(diff < 0)
  {
    return 0;
  }
  else if(diff > 0)
  {
    return 180;
  }
}
