function [Phi] = PhiH(x)
%Kernel Density function
%d-variate Gaussian density for kernet Phi
%Input: Set of points
%Output kernel values
hr = 16;
hd1 = 21;
hd2 = 31;
d = 5;
H = [hr 0 0 0 0; 
     0 hr 0 0 0;
     0 0 hr 0 0;
     0 0 0 hd1 0;
     0 0 0 0 hd2]; %Bandwidth Matrix
 
 %H = H/H; % Too little values to compare against.

Phi = (det(H))^(-.5) * (2 * pi)^ (-d/2) * exp( -1/2 * x/H * x'); %(b/A = b* Inv(A))
