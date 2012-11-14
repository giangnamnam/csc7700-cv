function [Prob] = Prob_X_Psi_f(x,z)
%Input: y - set of points (r,g,b,x,y) in foreground
%Output: Probability that the candidate x is in foreground
Sum_PhiH = 0;
alpha = 0.01;
m = numel(z);
for i = 1 : m
    Sum_PhiH = Sum_PhiH + PhiH(x - z{i});
end
Prob = alpha* 1 + (1- alpha) *(1/m) *Sum_PhiH;