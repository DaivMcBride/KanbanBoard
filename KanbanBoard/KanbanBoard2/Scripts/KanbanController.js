
angular.module('kanbanBoard', [])
    .controller('kanbanController', function ($scope, $http) {
        //const response = await fetch(url, {
        //    method: 'POST', // *GET, POST, PUT, DELETE, etc.
        //    mode: 'cors', // no-cors, *cors, same-origin
        //    cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        //    credentials: 'same-origin', // include, *same-origin, omit
        //    headers: {
        //        'Content-Type': 'application/json'
        //        // 'Content-Type': 'application/x-www-form-urlencoded',
        //    },
        //    redirect: 'follow', // manual, *follow, error
        //    referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
        //    body: JSON.stringify(data) // body data type must match "Content-Type" header
        //});
        //fetch('http://localhost:23456/api/Kanban', {
        //    method: 'GET', // *GET, POST, PUT, DELETE, etc.
        //    mode: 'no-cors', // no-cors, *cors, same-origin
        //   // cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        //    //credentials: 'same-origin', // include, *same-origin, omit
        //    //headers: {
        //    //    'Content-Type': 'application/json'
        //    //    // 'Content-Type': 'application/x-www-form-urlencoded',
        //    //},
        //    //redirect: 'follow', // manual, *follow, error
        //    //referrerPolicy: 'no-referrer'//, // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
        //   // body: JSON.stringify(data) // body data type must match "Content-Type" header
        //}).
        //    then(response => {
        //        return response.json();
        //    }).then(
        //    user => {
        //        console.log(user);
        //    })
       
        let request = new XMLHttpRequest();
        request.open("GET", "http://localhost:23456/api/Kanban");

        request.send();
        request.onload = () => {
            console.log(request);
            if (request.status == 200) {
                console.log(JSON.parse(request.response));
            } else {
                console.log('error ${rquest.status} ${request.statusText}');
            }
        }
    });