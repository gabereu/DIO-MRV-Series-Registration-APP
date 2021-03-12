using System;
using Classes;

namespace Series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string opcaoUsuario = GetUserOption();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						Listing();
						break;
					case "2":
						InlcudeSerie();
						break;
					case "3":
						UpdateSerie();
						break;
					case "4":
						RemoveSerie();
						break;
					case "5":
						ShowSerie();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}
                AwaitUserInteraction();
                Console.Clear();
				opcaoUsuario = GetUserOption();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			// Console.ReadLine();
        }

        private static void AwaitUserInteraction(){
            Console.WriteLine();
            Console.WriteLine("Press ENTER to continue");
            Console.ReadKey();
        }

        private static string GetUserOption()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Series to your fun!!!");
			Console.WriteLine("Enter the desired option:");

			Console.WriteLine("1- Listing series");
			Console.WriteLine("2- Include new serie");
			Console.WriteLine("3- Update serie");
			Console.WriteLine("4- Remove serie");
			Console.WriteLine("5- Show serie");
			Console.WriteLine("X- Exit");
			Console.WriteLine();

			string userOption = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return userOption;
		}

        private static void Listing(){
            Console.WriteLine("Listing Series");
            var list = repository.Listing();
            if (list.Count == 0){
                Console.WriteLine("No series yet");
                return;
            }

            foreach (var serie in list)
            {
                Console.WriteLine($"- ID {serie.Id}: {serie.Title} {(serie.Removed ? "*Removed*" : "")}");
            }
        }

        private static void InlcudeSerie(){
            Console.WriteLine("Include new serie");
			var typeGenre = typeof(EGenre);
            foreach (var genres in Enum.GetValues(typeGenre))
            {
                Console.WriteLine($"{(int)genres}: {genres}");
            }
			Console.Write("Enter the genre between the options above: ");
			int genre = int.Parse(Console.ReadLine());

			Console.Write("Enter the Series Title: ");
			string title = Console.ReadLine();

			Console.Write("Enter the Year of Beginning of the Series: ");
			int year = int.Parse(Console.ReadLine());

			Console.Write("Enter the Series Description: ");
			string entradaDescricao = Console.ReadLine();

			Serie serie = new Serie(id: repository.NextId(),
										genre: (EGenre)genre,
										title: title,
										year: year,
										description: entradaDescricao);

			repository.Push(serie);
        }
		
		 private static void UpdateSerie()
		{
			Console.Write("Enter the series id: ");
			int serieIndex = int.Parse(Console.ReadLine());

			var typeGenre = typeof(EGenre);
            foreach (int genre_index in Enum.GetValues(typeGenre))
            {
                Console.WriteLine($"{genre_index}: {Enum.GetName(typeGenre, genre_index)}");
            }
			Console.Write("Enter the genre between the options above: ");
			int genre = int.Parse(Console.ReadLine());

			Console.Write("Enter the Series Title: ");
			string title = Console.ReadLine();

			Console.Write("Enter the Year of Beginning of the Series: ");
			int year = int.Parse(Console.ReadLine());

			Console.Write("Enter the Series Description: ");
			string entradaDescricao = Console.ReadLine();

			Serie serie = new Serie(id: serieIndex,
										genre: (EGenre)genre,
										title: title,
										year: year,
										description: entradaDescricao);

			repository.Update(serie);
		}

		private static void RemoveSerie()
		{
			Console.Write("Enter the series id: ");
			int serieIndex = int.Parse(Console.ReadLine());

			repository.Remove(serieIndex);
		}

        private static void ShowSerie()
		{
			Console.Write("Enter the series id: ");
			int serieIndex = int.Parse(Console.ReadLine());

			var serie = repository.GetById(serieIndex);

			Console.WriteLine(serie);
		}
    }

	
}
