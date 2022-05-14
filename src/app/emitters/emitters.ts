import { Component, OnInit, Output, EventEmitter } from '@angular/core';

export class Emitter {
   static authEmitter = new EventEmitter<boolean>();
}