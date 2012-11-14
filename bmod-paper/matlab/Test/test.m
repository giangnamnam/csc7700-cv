close all;
clear all;
im2 = imread('sea.jpg');
im = 255*im2double(im2);
R_val = im(:,:,1);
G_val = im(:,:,2);
B_val = im(:,:,3);

y_max = size(R_val,1);
x_max = size(R_val,1);
% x_val = 1;
% y_val = 1;
i = 1;
for x_Pos = 1 : x_max
    for y_Pos = 1 : y_max
        y{i} = [R_val(y_Pos,x_Pos) G_val(y_Pos,x_Pos) B_val(y_Pos,x_Pos) y_Pos x_Pos];
        i = i + 1;
    end
end

figure,imshow(im2);
[p1 p2]= select_foreground;

i = 1;
for x_Pos = p1(1) : p2(1)
    for y_Pos = p1(2) : p2(2)
        z{i} = [R_val(y_Pos,x_Pos) G_val(y_Pos,x_Pos) B_val(y_Pos,x_Pos) y_Pos x_Pos];
        i = i + 1;
    end
end
% %SET OF BACKGROUND 
% y{1} = [ 155 255 255 4 1];
% y{2} = [ 122 245 122 4 6];
% y{3} = [ 155 167 201 1 1];
% y{4} = [ 156 201 123 2 2];
% y{5} = [ 255 142 123 6 7];
% y{6} = [ 155 155 255 4 5];
% y{7} = [ 255 255 255 4 5]; %x will be in background as well as foreground
% % y{11} = [ 255 255 255 4 5];
% % y{10} = [ 255 255 255 4 5];
% % y{11} = [ 255 255 255 4 5];
% % y{12} = [ 255 255 255 4 5];
% 
% %SET OF FOREGROUND
% z{1} = [ 255 122 255 5 5];
% z{2} = [ 255 255 255 2 5];
% z{3} = [ 255 255 255 4 5]; %x is in foreground. Changing this will detect x to be background
% z{4} = [ 255 255 255 3 4];
% 
% 
% % y{6} = [ 255 122 255 5 5];
% % y{7} = [ 255 255 255 4 5];
% % y{8} = [ 255 255 255 4 5];
% % y{9} = [ 255 255 255 4 5];
% % y{10} = [ 255 255 255 4 5];
% % y{11} = [ 255 255 255 4 5];
% % y{12} = [ 255 255 255 4 5];
k = 2;
for i = 1 : k
%Candidate Pixel
def = Dialog;
x = [str2num(def{1}) str2num(def{2}) str2num(def{3}) str2num(def{4}) str2num(def{5})];


psi_b = Prob_X_Psi_b(x,y);
psi_f = Prob_X_Psi_f(x,z);

tau  = - log (psi_b/psi_f);

%Assuming K (threshold) is 1
k = 1;
tau
if tau > k
    display('foreground');
else
    display('background');
end

end
    
    



