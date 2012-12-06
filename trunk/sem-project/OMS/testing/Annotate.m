imgFiles = dir('*.jpg');
numPoints = 4;

for i = 1 : size(imgFiles),
  if imgFiles(i).isdir
    continue
  end
  imgFile = imgFiles(i).name;
  img = imread(imgFile);
  imshow(img);
  [x y] = ginput(numPoints);
  x = round(x);
  y = round(y);
  [~,imgFileName] = fileparts(imgFile);
  csvwrite([imgFileName '_annotate.txt'], [x, y]);
  close;
end
