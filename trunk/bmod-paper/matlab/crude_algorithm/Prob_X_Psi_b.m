function [Prob] = Prob_X_Psi_b(x,y)
%Input: y - set of points (r,g,b,x,y) in background
%Output: Probability that the candidate x is in background
Sum_PhiH = 0;
n = numel(y);
for i = 1 : n
    Sum_PhiH = Sum_PhiH + PhiH(x - y{i});
end
Prob = (1/n) *Sum_PhiH;