close all;
clear all;
clc;


%SET OF BACKGROUND 
y{1} = [ 155 255 255 4 1];
y{2} = [ 122 245 122 4 6];
y{3} = [ 155 167 201 1 1];
y{4} = [ 156 201 123 2 2];
y{5} = [ 255 142 123 6 7];
y{6} = [ 155 155 255 4 5];
y{7} = [ 255 255 255 4 5];


% %Normalize the values
for k = 1 : numel(y)
    y{k} = normalize(y{k});
end

%Candidate Pixel
x= [ 255 142 123 6 7];

%Normalize the Candidate Pixel
x = normalize(x);

psi_b = Prob_X_Psi_b(x,y);
