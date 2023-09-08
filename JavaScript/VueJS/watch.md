    watch:{
        valueInputDay : function(newValue, oldValue){

            var diff = newValue - oldValue;

            let indexValue = this.daysWeek.indexOf(parseInt(newValue)); // 28,29,30,31,1,2,3
            let indexOldValue = this.daysWeek.indexOf(parseInt(oldValue));

            if (diff == 1) {
                if (indexValue == -1) {

                    if((parseInt(indexOldValue) + 1) > 6){
                        this.valueInputDay = this.firstDayWeek;
                    }else{
                        this.valueInputDay = this.daysWeek[parseInt(indexOldValue) + 1];
                    }
                }
            } else if (diff == -1) {
                if (indexValue == -1) {
                    if((parseInt(indexOldValue) - 1) < 0){
                        this.valueInputDay = this.lastDayWeek;
                    }else{
                        this.valueInputDay = this.daysWeek[parseInt(indexOldValue) - 1]
                    }
                }
            }
        }
    },
