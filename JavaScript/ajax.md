# Ajax 

## Créer une function Ajax

<!DOCTYPE html>
<html>
<head>
    <title>Exemple AJAX en JavaScript Vanilla</title>
</head>
<body>
    <button id="btnLoadData">Charger les données</button>
    <div id="content"></div>

    <script>
        // Fonction pour effectuer la requête AJAX
        function getData() {
            var xhr = new XMLHttpRequest();
            xhr.onreadystatechange = function () {
                if (xhr.readyState === 4) {
                    if (xhr.status === 200) {
                        // La requête a réussi, mettez à jour le contenu de la page
                        document.getElementById("content").innerHTML = xhr.responseText;
                    } else {
                        // La requête a échoué, affichez un message d'erreur
                        console.error("Erreur lors de la requête AJAX : " + xhr.status);
                    }
                }
            };
            xhr.open("GET", "votre_url_de_requete", true);
            xhr.send();
        }

        // Ajoutez un écouteur d'événement sur le bouton pour déclencher la requête AJAX lorsque le bouton est cliqué
        document.getElementById("btnLoadData").addEventListener("click", getData);
    </script>
</body>
</html>