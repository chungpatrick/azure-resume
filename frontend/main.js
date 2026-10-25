window.addEventListener('DOMContentLoaded', (event) => {
   getVisitCount();
})

const functionApiURL = "https://getresumecounter-new-c2f8ddeyeag7cjb0.centralus-01.azurewebsites.net/api/GetResumeCounter?code=XoexKB63jwMrzY6U9shPP3Kpsy64XrP45r7hPGRqU3C1AzFueDuF5Q==";
const localFunctionApi = 'http://localhost:7071/api/GetResumeCounter';

const getVisitCount = () => {
    let count = 30;
    fetch(functionApiURL).then(response => {
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