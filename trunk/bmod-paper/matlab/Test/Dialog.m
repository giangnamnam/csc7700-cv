function def = Dialog
prompt = {'R value','G value','B value','y Pos', 'x Pos' };
dlg_title = 'Candidate Point';
num_lines = 1;
def = {'135','204','219','88','179'};
answer = inputdlg(prompt,dlg_title,num_lines,def);