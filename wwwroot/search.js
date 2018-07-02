var success = function successs() {
    return  "Found!";
    return  
  }

 var error = function errors() {
    return  "ERROR";
  }

  document.getElementById('PostInputForm').addEventListener('submit', performPostRequest);

function performPostRequest(e) {
  var postPath = document.getElementById('Path').value;
  var postPattern = document.getElementById('Pattern').value;
  axios.post('http://localhost:5002/api/search/searchFile', {
    path: postPath,
    pattern: postPattern, 
    headers: {
      "Content-Type": "application/json"
    
    }
  })
  .then(function(response) {
    console.log(response);
    var locateFile = function locate() {
       return response.data;
    }
    console.log(success());
    console.log("checking here..."+ locateFile()); 
  })
  .catch(function(error) {
    console.log(error);
    console.log(error());
  })
  e.preventDefault();
}
