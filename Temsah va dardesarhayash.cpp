//LA

#include <bits/stdc++.h>
using namespace std;
typedef long long int ll;
/* run this program using the console pauser or add your own getch, system("pause") or input loop */

ll mini; long double minimum;
ll h, c, f;

void Function(ll first, ll last){
	ll number = (first + last) / 2;
	long double fl = (number * h * 1.0 + (number - 1) * c * 1.0) / (2 * number * 1.0 - 1) * 1.0;
	if(last == first + 1){
		if (fabs(fl - f) < minimum){
			minimum = fabs(fl - f);
			mini = number;
		}
		return;
	}
	if (fabs(fl - f) < minimum){
		minimum = fabs(fl - f);
		mini = number;
	}
	if(fl < f) Function(first, number);
	else if(fl > f) Function(number, last);
	else if(fl == f) return;
}

int main() {
	ll n;
	cin>>n;
	for(int i = 0; i < n; i++){
		cin>>h>>c>>f;
		minimum = 1e9;
		if(f == (h + c) / 2){
			cout<<'2'<<endl;
			continue;
		}
		else if(f == h){
			cout<<'1'<<endl;
			continue;
		}
		Function(0, 9223372036854775807); //9,223,372,036,854,775,807
		cout<< 2 * mini - 1<<endl;
	}
}

