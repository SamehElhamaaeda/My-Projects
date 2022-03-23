#include <iostream>
#include<string>
using namespace std;
int the_last_number_for_books = 0, the_last_number_of_users = 0;

struct date
{
	int day, month, year;
};
struct data_of_users
{
	int id;
	string email, type_of_the_account, name, password;
	long long phone_number;
	date date_of_creat_in_theaccount;

}users[500];

struct books_of_the_library
{
	string title, category;
	int number_of_copies, price_of_one_book;
	date production_year;
}books[20];

void add_users()//this function is designed to make acounts for the new users;
{
	int  number_of_the_new_users;
	cout << "enter the number of the accounts do you want to add\n";
	cin >> number_of_the_new_users;
	//storing the data in of the user in the next place of the array; 
	for (int i = the_last_number_of_users;i < (number_of_the_new_users + the_last_number_of_users);i++)
	{
		cout << "enter the date (day,month,year)\n";
		cin >> users[i].date_of_creat_in_theaccount.day;
		cin >> users[i].date_of_creat_in_theaccount.month;
		cin >> users[i].date_of_creat_in_theaccount.year;
		cout << "enter the id \n";
		cin >> users[i].id;
		cout << "enter the name \n";
		cin.ignore();
		getline(cin, users[i].name);
		cout << "enter your email\n";
		cin.ignore();
		getline(cin, users[i].email);
		cout << "enter your phone number\n";
		cin >> users[i].phone_number;
		cout << "enter the type of the account\n";
		cin.ignore();
		getline(cin, users[i].type_of_the_account);
		cout << "make a password\n";
		cin.ignore();
		getline(cin, users[i].password);
		cout << "\n\n";
	}
	the_last_number_of_users += number_of_the_new_users;
}
void add_books() // this function for adding new types of books or adding acopies;
{
	string title;
	int number_of_addition_copies, number_of_new_types;
	int choice;
	char answer = 'y';
	bool penteration = false;
	cout << "if you want to add a new type of books press 1 \n" << "if you want to insert a copies press 2\n";
	cin >> choice;
	if (choice == 1)
	{
		cout << "enter how many types of books do you want to add\n";
		cin >> number_of_new_types;
		//adding a new types of books 
		for (int i = the_last_number_for_books;i < (number_of_new_types + the_last_number_for_books);i++)
		{
			cout << "enter the  title of  the book do you want to add\n";
			cin.ignore();
			getline(cin, books[i].title);
			cout << "enter the production year(day/month/year)\n";
			cin >> books[i].production_year.day >> books[i].production_year.month >> books[i].production_year.year;
			cout << "enter the number of copies\n";
			cin >> books[i].number_of_copies;
			cout << "enter the price of one book \n";
			cin >> books[i].price_of_one_book;
			cout << "enter the category of the book\n";
			cin.ignore();
			getline(cin, books[i].category);
			cout << "adding have sucseeded\n";
		}
		the_last_number_for_books += number_of_new_types;
	}
	else
	{ //adding a copies of existing books 
		while (answer == 'y' || answer == 'Y')
		{
			cout << "enter the title of the book which you want to add  a copies of \n";
			cin.ignore();
			getline(cin, title);
			cout << "enter the number of copies do you want to add \n";
			cin >> number_of_addition_copies;
			for (int j = 0;j < the_last_number_for_books;j++)
			{
				if (books[j].title == title)
				{
					books[j].number_of_copies += number_of_addition_copies;
					penteration = true;
					break;
				}
			}
			if (penteration == false)
				cout << "invalid title adding a copies have failed";
			cout << "do you want to do any other adding\n";
			cin >> answer;
		}
	}
}
/*this function for the four librarians are responsible for the daily activities such as creating accounts for the
new users, adding new types of books for the library and adding copies of the the books.*/
void admins()
{
	bool test_user_name = false, test_password = false;
	string password, user_name;
	char choice, answeer = 'y';
	do
	{
		cout << "enter the user name" << endl;
		cin >> user_name;
		cout << "enter the password\n";
		cin >> password;
		//first we chek the paasword
		if ((password == "$12020#") || (password == "$22020#") || (password == "$32020#") || (password == "$42020#"))
		{
			test_password = true;
			if (user_name == "admin") //cheking the user name, all the users names for librarians are admin only
			{
				test_user_name = true;
				cout << " login has succeeded \n";
				do
				{
					cout << "press 1 to add a new acount for a user \n";
					cout << "press 2 if you want to add a new books \n";
					cin >> choice;
					switch (choice)
					{
					case'1':
						add_users();
						break;
					case'2':
						add_books();
						break;
					default:
						cout << "invalid choice\n";

					}
					cout << "if you want to do anothere operation press(y,Y)\n";
					cin >> answeer;
				} while (answeer == 'y' || answeer == 'Y');//cheking if the user want to do another operation
			}
		}
		else if (test_user_name == 0 || test_password == 0)
		{
			cout << "invalid user name or password\n";
			cout << "if you want to try to login again press y\n";
			cin >> answeer;
		}

	} while (answeer == 'y' || answeer == 'Y');

}


void searching()// this function enable the user to search for books with the user name and password 
{
	bool pentesting, testing;
	char answer, choice;
	string password, username, type_of_account, title;
	date productionyear;
	do
	{
		//pentesting = false;
		//testing = false;
		cout << "enter your  name\n";
		cin.ignore();
		getline(cin, username);
		cout << "enter the password\n";
		cin.ignore();
		getline(cin, password);

		for (int i = 0;i < the_last_number_of_users;i++) //searching if the user have an account or not
		{
			if (username == users[i].name)// cheking if the user name is correct
			{
				if (password == users[i].password)//chekiing if the password is correct
				{
					pentesting = true;
					type_of_account = users[i].type_of_the_account;
				}
			}
		}

		if (pentesting == true)
		{
			do
			{
				if (type_of_account == "staff") //cheking  if the type account of th user is staff to enable him to buy books
				{
					testing = true;
					cout << "enter 1 to search for a book with title\n";
					cout << "enter 2 to searc for a book with the production year\n";
					cin >> choice;
				}
				else
				{
					cout << "enter 1 to search for a book with title\n";
					cout << "enter 2 to searc for a book with the production year\n";
					cin >> choice;
				}
				switch (choice)
				{
				case'1':
					cout << "enter the title of the book\n";
					cin.ignore();
					getline(cin, title);
					for (int y = 0;y < the_last_number_for_books;y++)
					{
						if (title == books[y].title)//finding the book which the user search about with the title
						{
							cout << "the production year is  " << books[y].production_year.day << "/";
							cout << books[y].production_year.month << "/" << books[y].production_year.year << endl;
							cout << "the category is " << books[y].category << endl;
							cout << "the available copies of this book " << books[y].number_of_copies << endl;;
							cout << "the price of the book is " << books[y].price_of_one_book << endl;
							if (testing == true)
							{
								cout << "if you want to buy acopy of the book press 3\n";
								cin >> answer;
								if (answer == 3)
								{
									if (books[y].number_of_copies > 0)//search for a copy of the book to sell
									{
										books[y].number_of_copies--;
										cout << "buying has succeeded\n";
									}
									else
									{
										cout << "there are no available copy of this book\n";
									}
								}
							}
						}
					}
					break;
				case'2':
					cout << "enter the production year  of the book\n";
					cin >> productionyear.day >> productionyear.month >> productionyear.year;
					for (int o = 0;o < the_last_number_for_books;o++)
					{
						// finding the book which the user search about with the production year
						if (books[o].production_year.day == productionyear.day && books[o].production_year.month == productionyear.month && books[o].production_year.year == productionyear.year)
						{
							cout << "the title of the book is  " << books[o].title << endl;
							cout << "the categoryis " << books[o].category << endl;
							cout << "the available copies of this book " << books[o].number_of_copies << endl;
							cout << "the price of the book is " << books[o].price_of_one_book << endl;
							if (testing == true)
							{
								cout << "if you want to buy acopy of the book press 3\n";
								cin >> answer;
								if (answer == 3)
								{
									if (books[o].number_of_copies > 0)//search for a copy of the book to sell
									{
										books[o].number_of_copies--;
										cout << "buying has succeeded\n";
									}
									else
									{
										cout << "there are no available copy of this book\n";
									}
								}
							}
						}
					}
					break;

				default:
					cout << "invalid choice\n";
					break;
				}
				cout << "if you want to search for another book press (y/Y)\n";
				cin >> answer;
			} while (answer == 'Y' || answer == 'y');// if the user want to do another searching
		}
		else if (pentesting == false)
		{
			cout << "invalid user name or password\n";
		}
		cout << "if you want to log in again press(Y/y)\n";
		cin >> answer;

	} while (answer == 'Y' || answer == 'y');//if there are another user want to login

}
/* this function is desighned to display th data of the new users,
whose accounts were created within the last 7 days*/
void display_accounts()
{
	int the_rest_days;
	date date_of_the_last7accounts;
	cout << "enter the date\n";
	cin >> date_of_the_last7accounts.day >> date_of_the_last7accounts.month >> date_of_the_last7accounts.year;
	if (date_of_the_last7accounts.day >= 7)
	{
		date_of_the_last7accounts.day = date_of_the_last7accounts.day - 7;
		for (int i = 0;i < the_last_number_of_users;i++)
		{
			if (date_of_the_last7accounts.year == users[i].date_of_creat_in_theaccount.year && date_of_the_last7accounts.month == users[i].date_of_creat_in_theaccount.month)
				if (users[i].date_of_creat_in_theaccount.day > date_of_the_last7accounts.day)
				{
					cout << "the user data is\n";
					cout << "the id  " << users[i].id << endl;
					cout << "the name is  " << users[i].name << endl;
					cout << "the email is " << users[i].email << endl;
				}
		}
	}
	else if (date_of_the_last7accounts.day < 7) //if the date of days is less than 7  and the month is the next   
	{
		the_rest_days = 7 - date_of_the_last7accounts.day;
		for (int g = 0;g < the_last_number_of_users;g++)
			if (users[g].date_of_creat_in_theaccount.year == date_of_the_last7accounts.year && date_of_the_last7accounts.month == (users[g].date_of_creat_in_theaccount.month + 1))
			{
				if ((the_rest_days + users[g].date_of_creat_in_theaccount.day) >= 30)

					cout << "the user data is\n";
				cout << "the id  " << users[g].id << endl;
				cout << "the name is  " << users[g].name << endl;
				cout << "the email is " << users[g].email << endl;

			}
	}

}
void main()
{
	char answer, choice;
	do
	{

		cout << "\t\tthe main menu\n" << endl;

		cout << "if you want to log in as an admin press 1\n";
		cout << "if you want to log in an user press 2 \n";
		cout << "if you want to display the new accounts on the last 7 days press 3\n";
		cin >> choice;
		switch (choice)
		{
		case'1':
			admins();
			break;
		case'2':
			searching();
			break;
		case'3':
			display_accounts();
		default:
			cout << "invalid choice\n";
			break;
		}
		cout << "if you want to choose anothere choice from the main menu press y\n";
		cin >> answer;

	} while (answer == 'y' || answer == 'Y');
}