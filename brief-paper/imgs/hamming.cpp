#include <iostream>
using namespace std;

int main(){
	int x = 5, y = 15, hamming;
	
	__asm{
		mov eax, x
		xor eax, y
		popcnt eax, eax
		mov hamming, eax
	};

	cout << "Hamming distance: " << hamming << endl;

	return 0;
}