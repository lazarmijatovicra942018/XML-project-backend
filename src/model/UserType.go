package model

type Type int


const (
	Unregistered Type = iota
	Guest
	Host
)

