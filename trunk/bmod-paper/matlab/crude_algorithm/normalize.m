function [y] = normalize(y)
 temp = y;
    temp(1) = (temp(1)/255*15) + 1;
    temp(2) = (temp(2)/255*15) + 1;
    temp(3) = (temp(3)/255*15) + 1;
    temp(4) = (temp(4)/240*20) + 1;
    temp(5) = (temp(5)/360*30) + 1;
    y = temp;