function [Phi] = PhiH(x)
%Kernel Density function
%d-variate Gaussian density for kernet Phi
%Input: Set of points
%Output kernel values
hr = 16;
hd = 25;
d = 5;
H = [hr 0 0 0 0; 
     0 hr 0 0 0;
     0 0 hr 0 0;
     0 0 0 hd 0;
     0 0 0 0 hd]; %Bandwidth Matrix
 
 %H = H/H; % Too little values to compare against.
 %? or is it 5
Phi = (det(H))^(-.5) * (2 * pi)^ (-d /2) * exp( -1/2 * x/H * x'); %(b/A = b* Inv(A))
