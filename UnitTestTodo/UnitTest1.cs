using NUnit.Framework;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TestTodoAPI.Models;

namespace UnitTestTodo
{
    public class Tests
    {
        private string BASE_URL = "http://localhost:64967/api/todo/";
        private int todoId;
        private string title;
        private string datatype;
        [SetUp]
        public void Setup()
        {
            todoId = 1;
            title = "Test Todo";
            datatype = "Tommorrow";
        }

        [Test]
        public void Test1()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("getall");
                if(response.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
                {
                    Console.WriteLine(response.Result.Content.ReadAsStringAsync());
                    Assert.Pass();
                }
            }
            catch
            {
                Assert.Fail();
            }
        }

        public void Test2()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("gettodobyid/" + todoId);
                if (response.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
                {
                    Console.WriteLine(response.Result.Content.ReadAsStringAsync());
                    Assert.Pass();
                }
            }
            catch
            {
                Assert.Fail();
            }
        }

        public void Test3()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("gettodobytitle/" + title);
                if (response.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
                {
                    Console.WriteLine(response.Result.Content.ReadAsStringAsync());
                    Assert.Pass();
                }
            }
            catch
            {
                Assert.Fail();
            }
        }

        public void Test4()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("gettodobyexpirydate/" + datatype);
                if (response.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
                {
                    Console.WriteLine(response.Result.Content.ReadAsStringAsync());
                    Assert.Pass();
                }
            }
            catch
            {
                Assert.Fail();
            }
        }

        public void Test5()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("settodopercentcomplete/" + todoId);
                if (response.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
                {
                    Console.WriteLine(response.Result.Content.ReadAsStringAsync());
                    Assert.Pass();
                }
            }
            catch
            {
                Assert.Fail();
            }
        }

        public void Test6()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("removetodo/" + todoId);
                if (response.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
                {
                    Console.WriteLine(response.Result.Content.ReadAsStringAsync());
                    Assert.Pass();
                }
            }
            catch
            {
                Assert.Fail();
            }
        }

        public void Test7()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("markasdone/" + todoId);
                if (response.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
                {
                    Console.WriteLine(response.Result.Content.ReadAsStringAsync());
                    Assert.Pass();
                }
            }
            catch
            {
                Assert.Fail();
            }
        }


        public void Test8()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Todo todo = new Todo();
                todo.Detail = "New Todo New Detail";
                todo.ExpiryDate = DateTime.Now.AddDays(1);
                todo.IsDone = false;
                todo.PrecentageProgress = 0;
                todo.Title = "New Todo Title";
                var response = client.PostAsJsonAsync("create", todo);
                if (response.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
                {
                    Console.WriteLine(response.Result.Content.ReadAsStringAsync());
                    Assert.Pass();
                }
            }
            catch
            {
                Assert.Fail();
            }
        }

        public void Test9()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Todo todo = new Todo();
                todo.Detail = "New Todo New Detail";
                todo.ExpiryDate = DateTime.Now.AddDays(1);
                todo.PrecentageProgress = 0;
                todo.Title = "New Todo Title";
                var response = client.PostAsJsonAsync("update", todo);
                if (response.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
                {
                    Console.WriteLine(response.Result.Content.ReadAsStringAsync());
                    Assert.Pass();
                }
            }
            catch
            {
                Assert.Fail();
            }
        }
    }
}