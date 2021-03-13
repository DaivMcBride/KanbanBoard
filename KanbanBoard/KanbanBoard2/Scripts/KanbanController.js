
angular.module('kanbanBoard', [])
    .controller('kanbanController', function ($scope, $http) {

        function safeDigest() {
            try { if (!$scope.$$phase) $scope.$digest(); } catch (e) { }
        }
        $scope.getClass = function (card) {
            return card.Creating ? "redcard" : card.Active ? "redcard" :"card"
        }
        $scope.isCreate = function (card) {
            return card.Creating
        }
        $scope.Creating = false;
        $scope.isDisabled = function (card) {
            return !card.Creating  
        }
        $scope.activate = function (card) {
            if ($scope.Creating) return;
            deactivate($scope.board.backlog.cards)
            deactivate($scope.board.inProgress.cards)
            deactivate($scope.board.complete.cards)
            card.Active = true;
            safeDigest()
        }
        function deactivate(cards) {
            for (var x = 0; x < cards.length; x++) {
                cards[x].Active = false;
            }
        }
        $scope.cardBeingCreated = function () {
            return $scope.Creating 
        }
        $scope.toLeft = function (card) {
            if ($scope.Creating) return;
            card.cardProgress = card.cardProgress-1;
            SaveCardPosition(card);
        }
        $scope.toRigth = function (card) {
            if ($scope.Creating) return;
            card.cardProgress += 1;
            SaveCardPosition(card);
        }
        function returnCard(card) {
            return {
                ID: card.id,
                User: card.user,
                Description: card.description,
                CardProgress: card.cardProgress
            };
        }
        $scope.addCard = function () {
            deactivate($scope.board.backlog.cards)
            deactivate($scope.board.inProgress.cards)
            deactivate($scope.board.complete.cards)
            var card = newCard();
            $scope.board.backlog.cards.push(card);
            $scope.Creating = true;
        }
        function newCard() {
            return {
                id: $scope.board.lastID+1,
                user: "Sally Ride",
                description: "",
                cardProgress: 1,
                Creating:true
            };
        }
        function SaveCardPosition(cards) {
            //var card = { id: 1, user: "John Doe", description: "John Doe was here", cardprogress: 2 };
            var newcard = returnCard(cards)
            card = JSON.stringify(newcard)
            fetch('http://localhost:23456/api/Kanban/' + card, {
                method: 'POST', // *GET, POST, PUT, DELETE, etc.
                mode: 'cors', // no-cors, *cors, same-origin
              
            }).
                then(response => {
                    return response;
                }).then(
                    update => {
                        var test = update;
                        getStatus();
                    })
        }

        $scope.saveCard = function (card) {
            if (!$scope.Creating) return;
            $scope.Creating = false;
            SaveCard(card);
        }
        function SaveCard(cards) {
            //var card = { id: 1, user: "John Doe", description: "John Doe was here", cardprogress: 2 };
            var newcard = returnCard(cards)
            card = JSON.stringify(newcard)
            fetch('http://localhost:23456/api/Kanban/'+card, {
                method: 'PUT', // *GET, POST, PUT, DELETE, etc.
                mode: 'cors', // no-cors, *cors, same-origin
                
            }).
                then(response => {
                    return response;
                }).then(
                    save => {
                        getStatus();
                    })
        }
        $scope.board = {};
        function getStatus() {
            fetch('http://localhost:23456/api/Kanban', {
                method: 'GET', // *GET, POST, PUT, DELETE, etc.
                mode: 'cors', // no-cors, *cors, same-origin
              
            }).
                then(response => {
                    return response.json();
                }).then(
                board => {
                    $scope.board = board;
                        safeDigest();
                    })
        }
        getStatus();
    });