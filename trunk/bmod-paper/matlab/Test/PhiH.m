function [Phi] = PhiH(x)
%Kernel Density function
%d-variate Gaussian density for kernet Phi
%Input: Set of points
%Output kernel values
H = [16 0 0 0 0; 
     0 16 0 0 0;
     0 0 16 0 0;
     0 0 0 25 0;
     0 0 0 0 25]; %Bandwidth Matrix
 
 %H = H/H; % Too little values to compare against.
d = 5; %? or is it 5
Phi = (det(H))^(-.5) * (2 * pi)^ (-d /2) * exp( -1/2 * x/H * x'); %(b/A = b* Inv(A))
