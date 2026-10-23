window.addEventListener('DOMContentLoaded', (event) => {
   getVisitCount();
})

const functionApiURL = "https://getresumecounter-new-c2f8ddeyeag7cjb0.centralus-01.azurewebsites.net/api/GetResumeCounter?code=xfpT8r7VVKVP3hDCzpfLjkwP9s0ONRdBH7fxJ9_4QKYOAzFuduJFJA==";
const localFunctionApi = 'http://localhost:7071/api/GetResumeCounter';

const getVisitCount = () => {
    let count = 30;
    fetch(functionApi).then(response => {
        return response.json();
    }).then(response => {
        console.log("Website called function API.");
        count = response.count;
        document.getElementById('counter').innerText = count;
    }).catch(function (error) {
        console.log(error);
    });
    return count;
}