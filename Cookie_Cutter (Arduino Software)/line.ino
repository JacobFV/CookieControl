void moveLine()
{
  unsigned long dx = Xend - Xstart;
  unsigned long dy = Yend - Ystart;
  distance = sqrt(sq(Xstart - Xend)
                + sq(Ystart - Yend));
  moveTo(Xstart,Ystart,false);
  while(t<1)
  {
    moveTo(t*dx+Xstart,
           t*dy+Ystart,
           true);
    t+= accuracy / distance;
  }
}
