using BlogApp.Domain;
using BlogApp.Repositories;
using BlogApp.Services;
using NSubstitute;
using Xunit;

namespace BlogApp.UnitTests
{
    public class PostServiceTests
    {
        [Fact]
        public void TitleAndContentAreValid_Called_ReturnCreatedPost()
        {
            // Arrange
            const string title = "Testes unitários com NSubstitute e .NET Core";
            const string content = "Lorem ipsum dolor sit amet, consectetur adipiscing.";
            var post = new Post(title, content);

            IPostRepository postRepositorySubstitute = Substitute.For<IPostRepository>(); // Criando um substituto
            postRepositorySubstitute.Add(title, content).Returns(post); // Definindo o comportamento do método Add

            var postService = new PostService(postRepositorySubstitute);

            // Act
            var createdPost = postService.Create(title, content);

            // Assert
            Assert.NotNull(createdPost);
            postRepositorySubstitute.Received().Add(title, content); // verificando se o método Add foi chamada com os parâmetros passados
            Assert.Equal(title, createdPost.Title);
            Assert.Equal(content, createdPost.Content);
        }
    }
}
