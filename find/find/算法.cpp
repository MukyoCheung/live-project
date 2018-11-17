#include"windows.h"
#include<iostream>
#include<fstream>
#include<string>
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
using namespace std;

int main()
{
	char c;
	int line = 0,a[1000],i,n=1,t=0;//行数 
	fstream fin1("test.txt",ios::in);
	if(!fin1)
	{
		cerr<<"cannot open test"<<endl;
		return -1;
		
	}
	while(fin1.get(c))
	{
		if(c=='\n')
		line++;//行数加1 
	} 
	for(i=1;i<=line;i++)
	{
		a[n]=i;n++;
	 } 
	 
	 srand((unsigned)time(NULL));
  	 t = rand()%line;
	 printf("%d\n",a[t]);

} 
