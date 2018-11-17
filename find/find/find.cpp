// 抽奖.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include <regex>
#include <string>
#include <fstream>
#include <map>
using namespace std;

struct chat {
	string time;
	string name;
	int p() {
		cout << time << endl;
		cout << name << endl;
		return 0;
	}
};
struct ki {
	string key;
	string name;
	int p() {
		cout << key << " ";
		cout << name << endl;
		return 0;
	}
	bool operator <(const ki& other) const
	{
		if (key < other.key)        //类型按升序排序
		{
			return true;
		}
		else if (key == other.key)  //如果类型相同，按比例尺升序排序
		{
			return name < other.name;
		}

		return false;
	}

};
map <ki, int> lll;
bool check(string str) {
	regex r("[0-9]{4}-[0-9]{2}-[0-9]{2} [0-9]{1,2}:[0-9]{2}:[0-9]{2} [^ \f\n\r\t\v]*(\\([0-9]{1,}\\)|\\<[^ \f\n\r\t\v]*\\>)");
	return regex_match(str, r);
}
chat search(string str) {
	chat a;
	smatch sm;
	for (auto it = str.cbegin(); regex_search(it, str.cend(), sm, regex("[0-9]{4}-[0-9]{2}-[0-9]{2} [0-9]{1,2}:[0-9]{2}:[0-9]{2}")); it = sm.suffix().first) {
		for (auto aa : sm) a.time = aa.str();
		a.name = sm.suffix().str().erase(0, 1);
	}
	return a;
}
bool sea(string str, chat a) {
	smatch sm;
	ki lj;
	for (auto it = str.cbegin(); regex_search(it, str.cend(), sm, regex("#[^ \f\n\r\t\v]*?#")); it = sm.suffix().first) {
		for (auto aa : sm) {
			lj.key = aa.str();
			lj.name = a.name;
			lll[lj] = 1;
			//  cout << aa.str() << endl;

		}
	}
	return 1;
}
int  aaaa() {
	ki o;
	map<ki, int>::iterator itor;

	for (itor = lll.begin(); itor != lll.end(); itor++) {
		o = itor->first;
		o.p();
	}
	return 1;
}
int main()
{
	ifstream fin("/Users/admin/Documents/hello/vv/vv/record.txt");
	string str;
	chat now;
	while (getline(fin, str)) {
		if (check(str)) now = search(str);
		else {
			sea(str, now);
		}
	}
	aaaa();
	fin.close();
	cout << endl;
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started:
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
