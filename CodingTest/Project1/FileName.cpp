#include <iostream>
using namespace std;
long long Generate(long long n);

int main()
{
	long long before = 0, after = 0, sum = 0;

	for (long long i = 1;i <= 5000;i++)
	{
		after = Generate(i);
		if (after > 5000) break;

		for (long long j = before + 1;j < after;j++)
		{
			sum += j;
		}
		before = after;
	}
	for (long long i = before+1;i <= 5000;i++)
	{
		sum += i;
	}
	cout << sum;
}

long long Generate(long long n)
{
	long long one=0, ten = 0, hun = 0, th = 0;
	th = n / 1000;
	hun = n / 100 % 10;
	ten = n / 10 % 10;
	one = n % 10;

	return th + hun + ten + one + n;
}