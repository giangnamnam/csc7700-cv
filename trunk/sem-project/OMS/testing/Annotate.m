imgFiles = dir();
numPoints = 3;

for i = 1 : size(imgFiles),
  if imgFiles(i).isdir
    continue
  end
  imgFile = imgFiles(i).name;
  img = imread(imgFile);
  imshow(img);
  [x y] = ginput(numPoints);
  [~,imgFileName] = fileparts(imgFile);
  csvwrite([imgFileName '_annotate.txt'], [x, y]);
  close;
end
