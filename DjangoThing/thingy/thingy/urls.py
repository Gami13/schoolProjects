from django.contrib import admin
from django.urls import include, path

urlpatterns = [
    path("", include("test.urls")),
    path("admin/", admin.site.urls),
]