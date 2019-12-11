const userName = "EliteAPI";
const repoName = "EliteAPI";

var repo = GithubAPI("users/" + userName + "/repos").filter(function(item) {
  return item.name === repoName;
})[0];  

var contributors = GithubAPI(
  "repos/" + userName + "/" + repoName + "/stats/contributors"
);

var releases = GithubAPI("repos/" + userName + "/" + repoName + "/releases");

var lastRelease = GithubAPI(
  "repos/" + userName + "/" + repoName + "/releases/" + releases[0].id
);

$("#stars").text(repo.stargazers_count);
$("#issues").text(repo.open_issues_count);
$("#contributors").text(contributors.length);
$("#version").text(lastRelease.tag_name);
$("#forks").text(repo.forks_count);
$("#watchers").text(repo.watchers_count);
$("#commit").text(timeSince(new Date(repo.pushed_at)));

function GithubAPI(api) {
  var response;

  $.ajax({
    url: "https://api.github.com/" + api,
    async: false,
    dataType: "json",
    success: function(data) {
      response = data;
    }
  });

  return response;
}
