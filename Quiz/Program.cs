using System;
using System.Collections.Generic;
using BCrypt.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Quiz;

public class Program
{
	public static void Main()
	{
		Program program = new Program();
		program.Run();
	}
	public void Run()
	{
		Console.WriteLine("Welcome to the Quiz Game!");
		User user = Login();
		if (user != null)
		{
			ShowMainMenu(user);
		}
	}
	public void ShowSettingsMenu(User user)
	{
		bool isRunning = true;
		while (isRunning)
		{
			Console.WriteLine("Settings:");
			Console.WriteLine("1. Change password");
			Console.WriteLine("2. Change date of birth");
			Console.WriteLine("3. Back to main menu");

			string input = Console.ReadLine();
			switch (input)
			{
				case "1":
					ChangePassword(user);
					break;
				case "2":
					ChangeDateOfBirth(user);
					break;
				case "3":
					isRunning = false;
					break;
				default:
					Console.WriteLine("Invalid choice. Please try again.");
					break;
			}
		}
	}
	public void ShowMainMenu(User user)
	{
		bool isRunning = true;
		while (isRunning)
		{
			Console.WriteLine("Choose an action:");
			Console.WriteLine("1. Start new quiz");
			Console.WriteLine("2. View results");
			Console.WriteLine("3. Top 20");
			Console.WriteLine("4. Settings");
			Console.WriteLine("5. Exit");

			string input = Console.ReadLine();
			switch (input)
			{
				case "1":
					StartQuiz(user);
					break;
				case "2":
					ViewResults(user);
					break;
				case "3":
					ShowTop20();
					break;
				case "4":
					ShowSettingsMenu(user);
					break;
				case "5":
					isRunning = false;
					break;
				default:
					Console.WriteLine("Invalid choice. Please try again.");
					break;
			}
		}
	}
	public void StartQuiz(User user)
	{
		Console.WriteLine("Select a quiz category:");
		// Показать список категорий

		// Загрузить вопросы для выбранной викторины

		// Пройти по вопросам
		foreach (var question in questions)
		{
			Console.WriteLine(question.Text);
			// Показать ответы
			// Собрать ответ пользователя
		}

		// Подсчитать результаты
		// Сохранить результаты
		// Показать результаты пользователя
	}
	public void ViewResults(User user)
	{
		// Загрузить результаты пользователя
		// Отобразить результаты
	}

	public void ShowTop20()
	{
		// Загрузить топ-20 результатов
		// Отобразить топ-20
	}
	public bool RegisterUser(string login, string password, DateTime dateOfBirth)
	{
		// Проверка на существование логина
		if (Users.Any(u => u.Login == login))
		{
			Console.WriteLine("This login is already taken.");
			return false;
		}

		// Хеширование пароля
		string passwordHash = BCrypt.HashPassword(password);

		// Создание и сохранение пользователя
		User newUser = new User { Login = login, PasswordHash = passwordHash, DateOfBirth = dateOfBirth };
		Users.Add(newUser);
		SaveUsers();

		Console.WriteLine("Registration successful!");
		return true;
	}

	public User LoginUser(string login, string password)
	{
		User user = Users.FirstOrDefault(u => u.Login == login);
		if (user != null && BCrypt.Verify(password, user.PasswordHash))
		{
			Console.WriteLine("Login successful!");
			return user;
		}

		Console.WriteLine("Invalid login or password.");
		return null;
	}
}
public class User
	{
		public string Login { get; set; }
		public string PasswordHash { get; set; }
		public DateTime DateOfBirth { get; set; }
	}

	public class Quiz
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public List<Question> Questions { get; set; }
	}

	public class Question
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public List<Answer> Answers { get; set; }
	}

	public class Answer
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public bool IsCorrect { get; set; }
	}

