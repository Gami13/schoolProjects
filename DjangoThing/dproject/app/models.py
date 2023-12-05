
from django.db import models
from django.contrib.auth.models import User


class Message(models.Model):
    message = models.CharField(max_length=200)
    user = models.ForeignKey(User, on_delete=models.CASCADE)
    created = models.DateTimeField(auto_now_add=True)
