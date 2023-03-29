package repository

import (
	"context"
	"time"
	"xml-project-backend/model"


//	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/bson/primitive"
//	"go.mongodb.org/mongo-driver/mongo"
)

type PublicRepository struct {
	UserCollection   *mongo.Collection
	FlightCollection *mongo.Collection
}



func (repo *PublicRepository) CreateUser(user *model.User) error {
	var ctx, cancel = context.WithTimeout(context.Background(), 5*time.Second)
	defer cancel()
	password := HashPassword(*user.Password)
	user.Password = &password
	user.Created_At, _ = time.Parse(time.RFC3339, time.Now().Format(time.RFC3339))
	user.Updated_At, _ = time.Parse(time.RFC3339, time.Now().Format(time.RFC3339))
	user.ID = primitive.NewObjectID()
	user.User_ID = user.ID.Hex()
	token, refreshtoken, _ := generate.TokenGenerator(*user.Email, *user.First_Name, *user.Last_Name, user.User_ID, models.Role(*user.Role))
	user.Token = &token
	user.Refresh_Token = &refreshtoken
	user.UserTickets = make([]primitive.ObjectID, 0)
	_, inserterr := repo.UserCollection.InsertOne(ctx, user)
	return inserterr
}


func HashPassword(password string) string {
	bytes, err := bcrypt.GenerateFromPassword([]byte(password), 14)
	if err != nil {
		log.Panic(err)
	}
	return string(bytes)
}