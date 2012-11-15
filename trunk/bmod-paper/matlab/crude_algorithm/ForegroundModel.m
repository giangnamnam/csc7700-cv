%SET OF FOREGROUND
z{1} = [ 255 122 255 5 5];
z{2} = [ 255 255 255 2 5];
z{3} = [ 255 255 255 4 5]; %x is in foreground. Changing this will detect x to be background
z{4} = [ 255 255 255 3 4];


%Normalize the values
for k = 1 : numel(z)
    z{k} = normalize(z{k});
end

%Candidate Pixel
x = [255 255 255 4 5];

%Normalize the Candidate Pixel
x = normalize(x);

psi_f = Prob_X_Psi_f(x,z);