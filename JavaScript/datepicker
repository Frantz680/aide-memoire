        // Lorsque l'on change la date on met a jour dans les datepickers
        // On vérrouille les dates déjà prises
        let datesPreavisEffectue = [];
        let datesPreavisNonEffectuePaye = [];
        let datesPreavisNonEffectueNonPaye = [];

        $('#preavis-effectue-du, #preavis-effectue-au, #preavis-non-effectue-paye-du, #preavis-non-effectue-paye-au, #preavis-non-effectue-non-paye-du, #preavis-non-effectue-non-paye-au').on('changeDate', function () {
            updateDatepickers();
        });

        // Fonction qui permet de bloquées les dates choisies
        function updateDatepickers() {
            datesPreavisEffectue = [];
            datesPreavisNonEffectuePaye = [];
            datesPreavisNonEffectueNonPaye = [];

            let startDateEffectue = $('#preavis-effectue-du').val();
            let endDateEffectue = $('#preavis-effectue-au').val();
            let startDateNonPaye = $('#preavis-non-effectue-paye-du').val();
            let endDateNonPaye = $('#preavis-non-effectue-paye-au').val();
            let startDateNonPayeNonEffectue = $('#preavis-non-effectue-non-paye-du').val();
            let endDateNonPayeNonEffectue = $('#preavis-non-effectue-non-paye-au').val();

            datesPreavisEffectue = getWeekWithTwoDate(startDateEffectue, endDateEffectue);
            datesPreavisNonEffectuePaye = getWeekWithTwoDate(startDateNonPaye, endDateNonPaye);
            datesPreavisNonEffectueNonPaye = getWeekWithTwoDate(startDateNonPayeNonEffectue, endDateNonPayeNonEffectue);

            let datesDisabled = datesPreavisEffectue.concat(datesPreavisNonEffectuePaye, datesPreavisNonEffectueNonPaye);

            // Mise à jour de tous les datepickers avec les dates bloquées
            $("#preavis-non-effectue-paye-du, #preavis-non-effectue-paye-au, #preavis-non-effectue-non-paye-du, #preavis-non-effectue-non-paye-au, #preavis-effectue-du, #preavis-effectue-au").datepicker('setDatesDisabled', datesDisabled);
        }

        // Fonction pour obtenir les jours manquants entre nos deux dates
        function getWeekWithTwoDate(startDate, endDate) {
            let dates = [];
            let currentDate = new Date(startDate);
            endDate = new Date(endDate);

            while (currentDate <= endDate) {
                dates.push(currentDate.toISOString().slice(0, 10));
                currentDate.setDate(currentDate.getDate() + 1);
            }
            return dates;
        }
