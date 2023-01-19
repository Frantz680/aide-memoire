import numpy as np
import pandas as pd
import matplotlib.pyplot as plt

data = pd.read_csv('data/titanic.csv')
print('\n')
print(data.head())
print('\n')

new_data = data.drop(['Name', 'PassengerId', 'SibSp', 'Parch', 'Ticket', 'Fare', 'Cabin', 'Embarked'], axis=1)

print(new_data.head())
print('\n')

print(new_data['Pclass'].value_counts())

new_data['Pclass'].value_counts().plot.bar()

plt.show()